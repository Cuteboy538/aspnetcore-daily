🛡️ .NET Core 7+ Rate Limiting Example
This repository demonstrates how to use native rate limiting middleware in ASP.NET Core (.NET 7 or higher) without any external packages.

🔍 What is Rate Limiting?
Rate limiting is a strategy used to control how many requests a user can make to an API over a given time period. It helps protect against:

🔐 Brute-force attacks on sensitive endpoints (e.g., login, OTP)

🌐 API abuse by anonymous users or scrapers

📉 Overconsumption of resources during high traffic

🔁 Flooding on specific endpoints or by specific users

✅ Built-in Strategies in .NET 7+
.NET 7 introduces first-class support for rate limiting with the following strategies:

FixedWindow

SlidingWindow

TokenBucket

ConcurrencyLimiter

💡 Use Case Example
Let’s say you want to allow:

Only 5 requests per 10 seconds per IP address

And queue up to 2 extra requests if the limit is reached

🧪 Code Example – Program.cs

<img width="3946" height="2220" alt="image" src="https://github.com/user-attachments/assets/74704e9a-8a48-4fc4-aaef-cbd407ee5d94" />

