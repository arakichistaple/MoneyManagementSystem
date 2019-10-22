SELECT UserName, MJR.ItemName AS f, ISNULL(MDM.ItemName, '') AS s, ISNULL(Detail, '') AS Detail, Date, Amounts, Share
FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) 
LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId)
LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId