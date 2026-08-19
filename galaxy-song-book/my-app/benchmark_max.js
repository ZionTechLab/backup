// Simulate the logic we want to optimize
function runBenchmark() {
  const NUM_OPTIONS = 10000;

  // Create large array of objects
  const data = Array.from({ length: NUM_OPTIONS }, (_, i) => ({
    id: i,
    name: `Name ${i}`,
    otherData: 'xyz'
  }));

  const options = data.slice(5000); // Filtered options missing the first 5000
  const selectedVal = '4999'; // Item missing from options, worst case for `options` search (searches all, doesn't find). Finds at end of `data` before slice.
  const keyField = 'id';

  // MEASURE CURRENT IMPLEMENTATION
  const startCurrent = performance.now();
  let finalOptionsCurrent = [...options];

  for (let i = 0; i < 1000; i++) {
    const selectedOpt = data.find(
      (o) => (o[keyField] ?? '').toString() === selectedVal
    );
    if (selectedOpt && !options.some((o) => (o[keyField] ?? '').toString() === selectedVal)) {
      finalOptionsCurrent = [selectedOpt, ...options];
    }
  }
  const endCurrent = performance.now();

  // MEASURE OPTIMIZED IMPLEMENTATION (check if it exists in options first using optimized JS loop)
  const startOptimized3 = performance.now();
  let finalOptionsOptimized3 = [...options];

  for (let i = 0; i < 1000; i++) {
    let foundInOptions = false;
    for (let j = 0; j < options.length; j++) {
      const val = options[j][keyField];
      if (val != null && val.toString() === selectedVal) {
        foundInOptions = true;
        break;
      }
    }

    if (!foundInOptions) {
      let selectedOpt;
      for (let j = 0; j < data.length; j++) {
        const val = data[j][keyField];
        if (val != null && val.toString() === selectedVal) {
          selectedOpt = data[j];
          break;
        }
      }
      if (selectedOpt) {
        finalOptionsOptimized3 = [selectedOpt, ...options];
      }
    }
  }
  const endOptimized3 = performance.now();

  console.log(`Current: ${(endCurrent - startCurrent).toFixed(2)} ms`);
  console.log(`Optimized 3 (check options first + for loops): ${(endOptimized3 - startOptimized3).toFixed(2)} ms`);
}

runBenchmark();
