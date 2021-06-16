# Neu (mk 2)

Functional concurrency.

The goal:

## Immutable by default

On extending types:
```
extend SomeType {

    func someImmutFunction() {

        // cannot make modifications to members of type being extended
    }

    var func someFunction() {

        // This `var` form (on function sig vs. param modifier) can only
        // be used when extending a type, and therefore implies mutation
        // of extended type.
    }
}
```

Parameter granular mutability:
```
func foo(
    passByValue: Int, // All pass by value is immutable
    passByOwn1: borrow Int, // All borrows default to immutable
    passByOwn2: borrow var Int, // Must use mutable version of borrow to modify
    passByOwn3: claim Int, // Claiming ownership still assumes immutable
    passByOwn4: claim var Int // Explicit
) {

}
```

Both forms can be mixed (if extend a type, of course).

Passing stack values by ref:

```
func foo(
    passValByRef1: ref Int, // can only be used in non async func
    passValByRef2: ref var Int // similar to pass by ownership semantics
) {

}
```

Cannot be used in `task`s or `actions`s. 

## Memory ownership

```
Borrow<Type>
VarBorrow<Type>
Own<Type>
VarOwn<Type>
```

```
alias RawPointer = Borrow<Any>
alias VarRawPointer = VarBorrow<Any>
```

## No GC/Classes

Everything is a struct, with possible 'alignment'. You may align to a primitive type
(e.g. Int32, Int64 etc.) or an interface (interfaces are denoted with an I). Interface alignment or implicit alignment (i.e. not specifying anything) means the system will
auto align your type [ABI implications?].


This effectively replaces inheritance, polymorphism and overloading (particularly
constructor overloading).

Creating a value on the stack is simple:

```
let a = MyType()
```

Heap/reference types is nearly as simple, with value semantics:

```
let a1 = use MyType()
var a2 = use MyType()
```

If scope still owns anything at end of execution (added by the compiler automagically):
```
free a1
```

Passing things around:
```
someFunc(someParam: ref myStackValue)
```

```
someFunc(someParam: lend myScopedType)
```

```
someFunc(someParam: grant myScopedType)
```

## C-Interop

| C Syntax  | Neu Syntax  |
|---|---| 
| `const Type *` | `Borrow<Type>` | 
| `Type *` | `MutableBorrow<Type>` |
|   |   | 
| `Type * const *` | `Borrow<Type>` |
| `Type * __strong *` | `VarOwn<Type>` |
| `Type **` | `VarBorrow<Type>` |
|   |   | 
| `const void *` | `Borrow<Any>` |
| `void *` | `VarBorrow<Any>` |


In C:
```
int main(int argc, char *argv[])
{
    return 0;
}
```

In Neu:
```
func main(argc: Int, argv: mut borrow Char[]) -> Int {

    return 0
}
```
functionally equivalent to:

```
func main(argc: Int, argv: MutableBorrow<Char[]>) -> Int {

    return 0
}
```

However, main is a bad example, it's actually:

```
func main(args: Array<String>) {

}
```

## Types

```
struct MyType {

}
```

```
enum MyEnum {

    case myCase
    case anotherCase(myParam: ParamType)
}
```

## Interfaces

```
interface IMyInterface {

}
```

```
extend MyType {
    var body: some IMyInterface {
        ...
    }
}
```

## Implementation

```
extend MyType {

}
```

```
extend MyItem: ISomeInterface {

}
```

## Aliasing

```
alias MyAlias = Thing
```

## Functions

```
func foo() {

    ...
}
```

```
func foo() -> Int {

    return 0
}
```

## Operators

`and` instead of `&&`, `or` instead of `||`

```
if a and b {

}
else if b or c {

}
```

v1.0 will have backward compatibility with a warning.

## Concurrency

```
task fooTask() {

    ...
}
```

```
task fooTask<T>() -> Result<T> {

    ...
}
```

```
await fooTask()
```

```
let a = async fooTask()
let b = async fooTask()

await a, b
```

```
extend MyType {

    func someFunction() {

        async someAsyncFunc()
    }

    // ^ two errors at return call site:
    //     - Failure to await all tasks
    //     - Incorrectly declared async
    //       body as func instead of task
}
```

## Concurrency (Actors)

```
actor MyActor {

    /// externally callable but actioned atomically
}

extend MyActor {

    action fooAction() {

    }
}
```
```
extend SomeExternalType {

    task callTheActor() {

        // must await as actions are async

        await localActor.fooAction() 
    }
}
```



# Detailed

## Control Flow

### IfStatement

```
if true {

}
```

```
if true {

}
else {

}
```

### TryCatch

```
do {
    let n = try someThrowableFunc()
}
catch {

}
```

### 

## Attributes

```
#yolo
func myFunc() {

}
```

## 