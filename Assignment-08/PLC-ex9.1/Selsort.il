  .method public hidebysig static default void SelectionSort(int32[] arr) cil managed
  {
    // Method begins at Relative Virtual Address (RVA) 0x20B8
    // Code size 57 (0x39)
    .maxstack 4
    .locals init(int32 V_0, int32 V_1, int32 V_2, int32 V_3)

    // 1. Loop 'int i = 0'
    IL_0000: ldc.i4.0           // Loads a nummeric constant of type int32 and push to stack
    IL_0001: stloc.0            // Pops value from stack to local variable at index 0 of base pointer
    IL_0002: br.s     IL_0032   // Unconditional Branch

    // 2. Loop 'int j = i + 1'
    IL_0004: ldloc.0            // Load i to top of stack 
    IL_0005: stloc.1            // Pop top value and store to local variable 1 i.e. least
    IL_0006: ldloc.0            // Load i to the top of the stack
    IL_0007: ldc.i4.1           // Push the value 1 to the top of the stack as int32
    IL_0008: add                // Add the two values on the top of stack and push the result
    IL_0009: stloc.3            // Store the value at the top of the stack to local variable 3
    IL_000a: br.s     IL_001a   // Unconditional branch

    // 2. Loop body
    IL_000c: ldarg.0            // Load arr to top of the stack      
    IL_000d: ldloc.3            // Load local variable 3 to top of the stack
    IL_000e: ldelem.i4          // Load element of the arr of type int32 based on the index from top of the stack
    IL_000f: ldarg.0            // Load arr to the top of the stack
    IL_0010: ldloc.1            // Load least to the top of the stack
    IL_0011: ldelem.i4          // Load element of the arr based on the index from the top of the stack 
    IL_0012: bge.s     IL_0016  // Branch if >= based on the two top values. Go to instruction 16
    IL_0014: ldloc.3            // Load j to top of the stack
    IL_0015: stloc.1            // Store top of the stack to least variable

    // 2. Loop 'j++'
    IL_0016: ldloc.3            // Load j to top of the stack
    IL_0017: ldc.i4.1           // Load 1 of int32 to the top of the stack
    IL_0018: add                // Add the two top values and push to the stack
    IL_0019: stloc.3            // Store the above result to j

    // 2. Loop signature. Conditional of 'j < arr.length'
    IL_001a: ldloc.3            // Load local variable 3 to the top of the stack i.e. j
    IL_001b: ldarg.0            // Load argument 0 to the top of the stack i.e. the arr
    IL_001c: ldlen              // Get the len of the array and push value to the stack
    IL_001d: conv.i4            // Convert len value to int32
    IL_001e: blt.s     IL_000c  // Branch on < i.e. if j < arr.Length then go to instruction 0c 

    // This represents the 'int tmp = ...'
    IL_0020: ldarg.0            // Load arr to top of the stack      
    IL_0021: ldloc.0            // Load local variable 0 to the top of the stack. i.e i
    IL_0022: ldelem.i4          // Load element of the arr of type int32 based on the index from top of the stack
    IL_0023: stloc.2            // Store the above element to local variable 2, i.e tmp. (Previously j, but is now recycled). 
    IL_0024: ldarg.0            // Load arr to the top of the stack
    IL_0025: ldloc.0            // Load local variable 0 to the top of the stack. i.e. i
    IL_0026: ldarg.0            // Load arr to the top of the stack
    IL_0027: ldloc.1            // Load local variable 0 to the top of the stack. i.e. least
    IL_0028: ldelem.i4          // Load element of the arr of type int23 based on the index from the top of the stack. i.e. arr[least]
    IL_0029: stelem.i4          // Store to element at index on top of the stack, the value being the second value on the stack. i.e. arr[i] = arr[least]
    IL_002a: ldarg.0            // Load arr to the top of the stack
    IL_002b: ldloc.1            // Load local variable 1 to the top of the stack. i.e. least
    IL_002c: ldloc.2            // Load local variable 2 to the top of the stack. i.e. tmp
    IL_002d: stelem.i4          // Store to element at index on top of the stack, the value being the second value on the stack. i.e. arr[least] = tmp

    // 1. Loop 'i++'
    IL_002e: ldloc.0
    IL_002f: ldc.i4.1
    IL_0030: add
    IL_0031: stloc.0

    // 1. Loop signature. Conditional of 'i < arr.length'
    IL_0032: ldloc.0            // Loads i to the top of the stack
    IL_0033: ldarg.0            // Load argument 0 to the top of the stack i.e. the array
    IL_0034: ldlen              // Pushes the length of arr to the top of the stack
    IL_0035: conv.i4            // Convert the top value to int32
    IL_0036: blt.s     IL_0004  // Branch on < i.e. if i < arr.Length then go to instruction 4
    IL_0038: ret                // return... loops is done
  } // End of method System.Void Selsort::SelectionSort(System.Int32[])
