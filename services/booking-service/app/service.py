from .database import booking_collection
from .models import booking_helper
from bson import ObjectId, errors
from .billing_client import create_invoice

async def create_booking(data):
    booking = await booking_collection.insert_one(data)
    new_booking = await booking_collection.find_one({"_id": booking.inserted_id})
    booking_data = booking_helper(new_booking)

    items = [
        {
            "description": "Movie Ticket",
            "quantity": data.get("quantity", 1),
            "unit_price": 12.5,
            "line_total": data.get("quantity", 1) * 12.5
        }
    ]

    total_amount = sum(item["line_total"] for item in items)

    invoice_response = create_invoice(
        str(booking_data["id"]),
        items,
        total_amount
    )

    booking_data["invoice"] = invoice_response
    return booking_data


async def get_booking(id: str):
    booking = await booking_collection.find_one({"_id": ObjectId(id)})
    return booking_helper(booking) if booking else None


async def get_all_bookings():
    bookings = []
    async for booking in booking_collection.find():
        bookings.append(booking_helper(booking))
    return bookings


# ✅ PUT IT HERE — this is the correct place
async def delete_booking(id: str):
    try:
        result = await booking_collection.delete_one({"_id": ObjectId(id)})
        return result.deleted_count > 0
    except errors.InvalidId:
        return False
