-- Create the Weather database
CREATE DATABASE Weather;
GO

-- Use the Weather database
USE Weather;
GO

-- Create the WeatherForecasts table
CREATE TABLE WeatherForecasts (
    WeatherForecastId INT PRIMARY KEY IDENTITY(1,1),
    DateAndTime DATETIME,
    TemperatureC INT,
    Summary NVARCHAR(MAX)
);
GO