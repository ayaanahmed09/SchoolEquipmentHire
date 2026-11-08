SELECT BookingID, UserID, EquipmentID, BookingDate, ReturnDate, Status
FROM Booking
WHERE Status = 'Pending';