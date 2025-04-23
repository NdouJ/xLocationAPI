 Key Features
📡 Search for locations within a specified radius based on latitude and longitude (lat/lng provided in the request body).

🌐 Fetch data from public services such as Google Places or Foursquare.

💾 Log all successful requests and responses into a database using Entity Framework.

📜 RESTful design with proper HTTP methods and status codes.

🔍 Endpoint to retrieve stored requests, with support for:

filtering by category

searching through the list

📢 SignalR integration to notify subscribers in real-time whenever a new search is performed.

🖥 Console client that subscribes to the SignalR hub and displays incoming search events.

🔐 Basic Authentication that links an API key to each user.

⭐ Support for saving favorite locations per user.

🔁 Idempotency to ensure repeated requests with the same data don’t cause duplicates.

🚀 Optional Advanced Feature
⏳ Synchronous execution per user: Ensures that if a user sends multiple requests, they are processed one at a time, in order.
