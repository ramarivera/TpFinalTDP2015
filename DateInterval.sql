use DigitalSignage;


SELECT di.Id as DateID, di.Name, 
		ti.Id as TimeID, ti.Start, ti.[End]
FROM DigitalSignage.MARR.DateInterval as di
	JOIN DigitalSignage.MARR.TimeInterval as ti ON ti.DateIntervalId = di.Id;

	
SELECT di.Id as DateID, di.Name,
		d.Id as DayID, d.NameOfDay, d.Value
FROM DigitalSignage.MARR.DateInterval as di
	INNER JOIN DigitalSignage.MARR.DateIntervalDay as did ON di.Id = did.DateIntervalId
	INNER JOIN DigitalSignage.MARR.[Day] as d ON d.id = did.DayId;



use master;