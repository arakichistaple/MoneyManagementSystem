SELECT DATEPART(YEAR, ttt.Date)  AS NENDO
     , DATEPART(MONTH, ttt.Date) AS TUKI
     , SUM(ttt.Amounts)
FROM  (SELECT Date,
              Amounts, 
              ISNULL(Detail, '') AS Detail,
              UserName,
              MJR.ItemName AS MjrItemName,
              ISNULL(MDM.ItemName, '') AS MdmItemName 
       FROM   (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) 
               LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) 
               LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId 
       WHERE   MJR.PaymentId = 1 
       AND     Date >=  CONVERT(DATETIME, '2020/01/01')) AS ttt
GROUP BY DATEPART(YEAR, ttt.Date)
       , DATEPART(MONTH, ttt.Date)
ORDER BY NENDO, TUKI