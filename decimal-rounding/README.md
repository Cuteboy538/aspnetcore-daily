
🚀 ASP.NET Core Tip – Format Decimal Inputs with a Custom TagHelper 💡

Working with decimal values in Razor forms can be tricky — especially when precision and formatting matter.

To solve this, I created a custom TagHelper that automatically formats decimal and nullable decimal values for <input> fields using a consistent decimal pattern like "0.########". This ensures that unnecessary trailing zeros are avoided and values are always rendered cleanly in the UI.

📦 Key Features:

 ✅ Works with both decimal and decimal?

 ✅ Auto-formats input value using invariant culture

 ✅ Easy to apply with just asp-for
