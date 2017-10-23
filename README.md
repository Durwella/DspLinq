# DspLinq

A set of Extension Methods for performing basic digital signal processing operations on collections in the spirit of [Linq Enumerable Extensions](https://msdn.microsoft.com/en-us/library/system.linq.enumerable(v=vs.110).aspx) and [MoreLinq](https://morelinq.github.io).

<https://www.nuget.org/packages/Durwella.DspLinq/>

### Decimate

Skips every 10th element.

### Downsample

Keeps only every Nth element.

# Signal Generation

A set of static functions on the `Generate` class for generating infinite sequences.

### Generate.Constant

Produces an inifinte signal of the given amplitude value.

### Generate.Square

Produces a square wave that oscillates between amplitude and -amplitude.