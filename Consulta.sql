use DigitalSignage;

SELECT TOP 1000 [Id]
      ,[Start]
      ,[End]
      ,[CreationDate]
      ,[LastModified]
  FROM [DigitalSignage].[MARR].[TimeInterval];

SELECT TOP 1000 [Id]
      ,[Value]
      ,[NameOfDay]
      ,[CreationDate]
      ,[LastModified]
  FROM [DigitalSignage].[MARR].[Day];

  SELECT TOP 1000 [Id]
      ,[Name]
      ,[ActiveFrom]
      ,[ActiveUntil]
      ,[CreationDate]
      ,[LastModified]
  FROM [DigitalSignage].[MARR].[DateInterval];


  SELECT TOP 1000 [DateIntervalId]
      ,[DayId]
  FROM [DigitalSignage].[MARR].[DateIntervalDay];

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [DateIntervalId]
      ,[TimeIntervalId]
  FROM [DigitalSignage].[MARR].[DateIntervalTimeInterval];

  use master;