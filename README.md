# LazyConditions

### Example
```csharp
using LazyConditions;
using System.Threading.Tasks;

namespace Samples
{
    public class Sample
    {
        public async Task<bool> Validate()
        {
            return await Conditions.AllFalseAsync(
                LazyTask<bool>.Create(() => Task.FromResult(false)).Get(),
                LazyTask<bool>.Create(async () => await ValidateSomenthing()).Get(),
                LazyTask<bool>.Create(async () => await ValidateAnoterThing()).Get()
            );
        }

        private async Task<bool> ValidateSomenthing()
        {
            return true;
        }

        private async Task<bool> ValidateAnoterThing()
        {
            return false;
        }
    }
}

```
