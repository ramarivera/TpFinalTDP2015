use DigitalSignage;


SELECT di.Id as DateID, di.Name, 
		ti.Id as TimeID, ti.Start, ti.[End]
FROM DigitalSignage.MARR.DateInterval as di
	LEFT JOIN DigitalSignage.MARR.DateIntervalTimeInterval as diti ON diti.DateIntervalId = di.Id
	LEFT JOIN DigitalSignage.MARR.TimeInterval as ti ON ti.Id = diti.TimeIntervalId;


SELECT di.Id as DateID, di.Name,
		d.Id as DayID, d.NameOfDay, d.Value
FROM DigitalSignage.MARR.DateInterval as di
	LEFT JOIN DigitalSignage.MARR.DateIntervalDay as did ON di.Id = did.DateIntervalId
	LEFT JOIN DigitalSignage.MARR.[Day] as d ON d.id = did.DayId;




use master;