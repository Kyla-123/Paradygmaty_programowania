from functools import reduce

mojalist = [1,2,3,4,5]
newList = [x ** 2 for x in mojalist if x % 2 ==0]
print(newList)

#map() filter() reduce()
newList1 = (map(lambda x: x*2, mojalist))
print(newList1)

newList2 = list(filter(lambda x: x % 2 ==0, mojalist))
print(newList2)

newList3 = reduce(lambda x, y: x+y, mojalist)
print(newList3)


input = "2+2-56+125"
output = eval(input)
print(output)
