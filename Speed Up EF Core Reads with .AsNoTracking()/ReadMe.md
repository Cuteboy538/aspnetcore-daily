# 🧠 .NET Core Tip – Speed Up EF Core Reads with `.AsNoTracking()`

By default, Entity Framework Core **tracks every queried entity** — even if you're only reading data.  
That tracking adds **CPU and memory overhead**, especially for **large datasets**.

If you're working with **read-only scenarios** (like APIs, reports, or dashboards), you can disable tracking to **boost performance** significantly. ⚡

---

## ✅ Benefits

- 🚀 Faster queries  
- 🧠 Lower memory usage  
- 🔍 Ideal for read-only endpoints  

> ⚠️ **Important**: Don’t use `.AsNoTracking()` if you plan to **modify and save** the data — EF needs tracking for `SaveChanges()` to work.

---

## ✅ How to Use It

![AsNoTracking](https://github.com/user-attachments/assets/23ba00bd-a0a6-4659-be63-84392a4643c5)
