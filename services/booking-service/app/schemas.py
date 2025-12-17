from pydantic import BaseModel
from typing import Optional

class BookingCreate(BaseModel):
    customer_name: str
    movie_id: str
    schedule_id: str
    seat: str

class Booking(BaseModel):
    id: str
    customer_name: str
    movie_id: str
    schedule_id: str
    seat: str
