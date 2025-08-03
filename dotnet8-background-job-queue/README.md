# .NET 8 Background Job Queue (Minimal API + Channel + HostedService)

This project demonstrates how to implement a lightweight background job queue in .NET 8 using:

- `Channel<T>` for thread-safe in-memory queuing
- `BackgroundService` for processing jobs
- Minimal API to enqueue jobs at runtime

## 🔧 Use Case

Useful for offloading tasks like:
- Sending emails
- Processing files
- Background data syncing
- Delayed processing (e.g., retry logic, slow APIs)

---

## 🚀 How It Works

1. A POST request is made to `/enqueue`.
2. The API enqueues a background task using `Channel<T>`.
3. A hosted background worker dequeues and executes the job.

---

## 📦 Tech Stack

- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- Minimal APIs
- BackgroundService
- System.Threading.Channels

---

## ▶️ Run the App

```bash
dotnet run
