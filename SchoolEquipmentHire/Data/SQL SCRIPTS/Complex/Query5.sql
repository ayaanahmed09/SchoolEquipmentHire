SELECT BookingID, UserID, EquipmentID, ReturnDate, Status
FROM Booking
WHERE Status = 'Rejected';
