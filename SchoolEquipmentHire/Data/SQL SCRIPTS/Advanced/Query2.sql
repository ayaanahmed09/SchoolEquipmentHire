SELECT B.BookingID,
       E.EquipmentName,
       B.BookingDate,
       B.ReturnDate,
       B.Status
FROM Booking AS B
INNER JOIN Equipment AS E
    ON B.EquipmentID = E.ID;