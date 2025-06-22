# Gilded Rose starting position in C# NUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```


## Test Strategy and Challenges

We used NUnit to write unit tests for the Gilded Rose logic. Each item type, like Aged Brie, Sulfuras, and Backstage passes, has its own test cases. We made sure that SellIn and Quality values change the way they should after each update. We also tested edge cases, like making sure quality never drops below 0 or goes above 50. Each test focuses on just one specific thing, so it's easier to find problems if something breaks.

One small challenge was that the Item class didn't have a constructor, so we had to use object initializers instead. Another challenge was that the rules for how items behave weren't always clear, so we had to figure them out by carefully reading the existing code. Writing tests helped us understand the logic better and gave us more confidence in making changes.

## Refactoring Strategy and Challenges

We chose a big bang refactoring approach, meaning we threw out the old structure and rebuilt the logic from scratch. The original code was so messy and unclear that trying to patch it would have been more confusing than starting fresh.

We grouped the logic by item type, normal items, Aged Brie, Sulfuras, and Backstage passes, and moved each into its own method. This made the rules for each item clearer and reduced duplication. We also made sure to handle tricky parts like sell-in deadlines and quality limits correctly, especially for items like Backstage passes that have multiple conditions.

Our biggest challenge was that step-by-step refactoring would have meant a lot of unnecessary work in this specific case. Since the behavior was clear to us, a big bang refactor was simply the more efficient and cleaner solution.