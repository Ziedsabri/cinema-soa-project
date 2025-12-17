from fastapi import APIRouter, HTTPException
from .service import create_booking, get_booking, get_all_bookings, delete_booking
from .models import BookingModel

router = APIRouter()

@router.post("/bookings")
async def create_booking_route(data: BookingModel):
    return await create_booking(data.dict())


@router.get("/bookings/{id}")
async def get_booking_route(id: str):
    booking = await get_booking(id)
    if not booking:
        raise HTTPException(status_code=404, detail="Booking not found")
    return booking

@router.get("/bookings")
async def get_all_bookings_route():
    return await get_all_bookings()

@router.delete("/bookings/{id}")
async def delete_booking_route(id: str):
    deleted = await delete_booking(id)
    if not deleted:
        raise HTTPException(status_code=404, detail="Booking not found")
    return {"status": "deleted"}
