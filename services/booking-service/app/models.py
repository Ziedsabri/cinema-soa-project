from pydantic import BaseModel

class BookingModel(BaseModel):
    customer_name: str
    movie_id: str
    schedule_id: str
    seat: str
    amount: float
    quantity: int

def booking_helper(booking):
    return {
        "id": str(booking["_id"]),
        "customer_name": booking.get("customer_name"),
        "movie_id": booking.get("movie_id"),
        "schedule_id": booking.get("schedule_id"),
        "seat": booking.get("seat"),
        "amount": booking.get("amount", 0),
        "quantity": booking.get("quantity", 1)
    }
