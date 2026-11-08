SELECT B.BookingID,
       U.FirstName,
       U.LastName,
       B.EquipmentID,
       B.BookingDate,
       B.ReturnDate,
       B.Status
FROM Booking AS B
INNER JOIN AspNetUsers AS U
ON B.UserID = U.Id;
