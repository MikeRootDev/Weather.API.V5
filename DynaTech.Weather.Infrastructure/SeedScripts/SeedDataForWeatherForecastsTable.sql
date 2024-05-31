USE [Weather]
GO

INSERT INTO [dbo].[WeatherForecasts]
           ([DateAndTime]
           ,[TemperatureC]
           ,[Summary])
VALUES
(GETDATE(), 1, 'Freezing'),
(GETDATE(), 10, 'Klondike Derby'),
(GETDATE(), 20, 'Way Too Cold'),
(GETDATE(), 30, 'Chilly'),
(GETDATE(), 40, 'Warming Up'),
(GETDATE(), 50, 'Brisk'),
(GETDATE(), 60, 'Perfect'),
(GETDATE(), 70, 'Tad Warm'),
(GETDATE(), 80, 'Sweaty'),
(GETDATE(), 90, 'Oof'),
(GETDATE(), 100, 'Stay Inside'),
(GETDATE(), 110, 'Heat Stroke'),
(GETDATE(), 120, 'Typical New Mexico Day'),
(GETDATE(), 130, 'Surface of the Sun'),
(GETDATE(), 140, 'Fires of Hell'),
(GETDATE(), 150, 'Temperature Inside Pork'),
(GETDATE(), 160, 'Ouch')