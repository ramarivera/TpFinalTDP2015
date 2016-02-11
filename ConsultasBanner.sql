SELECT ba.Id,ba.Name,datei.Id as IntervalId,datei.Name as IntervalName
FROM DigitalSignage.MARR.Banner as ba
LEFT JOIN DigitalSignage.MARR.BannerInterval as bait ON bait.BannerId = ba.Id
LEFT JOIN DigitalSignage.MARR.DateInterval as datei ON datei.Id = bait.DateIntervalId


SELECT ba.Id,ba.Name,stext.Id as TextId,stext.Title as TextName, stext.Description
FROM DigitalSignage.MARR.Banner as ba
LEFT JOIN DigitalSignage.MARR.BannerBannerItem as bani ON bani.BannerId = ba.Id
LEFT JOIN DigitalSignage.MARR.BaseBannerItems as base ON base.Id = bani.BannerItemId
LEFT JOIN DigitalSignage.MARR.StaticText as stext ON stext.Id = base.Id;

SELECT ba.Id,ba.Name,rss.Id as SourceId, rss.Title as RssName
FROM DigitalSignage.MARR.Banner as ba
LEFT JOIN DigitalSignage.MARR.RssSource as rss ON rss.Banner_Id = ba.Id;
