Select
	Ticker,
	Date,
	COUNT(Id) As Population,
	AVG(PricePrediction)
from
	Positions
group by
	Ticker, Date