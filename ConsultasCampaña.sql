SELECT ca.Id,ca.Name,datei.Id as IntervalId,datei.Name as IntervalName
FROM DigitalSignage.MARR.Campaign as ca
LEFT JOIN DigitalSignage.MARR.CampaignDateInterval as cait ON cait.CampaignId = ca.Id
LEFT JOIN DigitalSignage.MARR.DateInterval as datei ON datei.Id = cait.DateIntervalId

