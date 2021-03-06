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

SELECT TOP 1000 [DateIntervalId]
      ,[TimeIntervalId]
  FROM [DigitalSignage].[MARR].[DateIntervalTimeInterval];


  SELECT TOP 1000 [Id]
      ,[Name]
      ,[Description]
      ,[CreationDate]
      ,[LastModified]
  FROM [DigitalSignage].[MARR].[Campaign]

  SELECT TOP 1000 [CampaignId]
      ,[DateIntervalId]
  FROM [DigitalSignage].[MARR].[CampaignDateInterval]

  SELECT TOP 1000 [Id]
      ,[Title]
      ,[Description]
      ,[Text]
  FROM [DigitalSignage].[MARR].[StaticText];

  SELECT TOP 1000 [Id]
      ,[CreationDate]
      ,[LastModified]
  FROM [DigitalSignage].[MARR].[BaseBannerItems];

  SELECT bbi.Id, bbi.CreationDate, bbi.LastModified, st.Description,st.Title, st.Text
 FROM [DigitalSignage].[MARR].[StaticText] as st
 JOIN [DigitalSignage].MARR.BaseBannerItems as bbi
 ON bbi.Id = st.id;

 SELECT TOP 1000 [Id]
      ,[Title]
      ,[Description]
      ,[URL]
      ,[CreationDate]
      ,[LastModified]
      ,[Banner_Id]
  FROM [DigitalSignage].[MARR].[RssSource]

  use master;