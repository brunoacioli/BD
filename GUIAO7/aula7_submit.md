# BD: Guião 7


## ​7.2 
 
### *a)*

```
1FN.
Considerando A = titulo,  B = Autor, C = Afiliação, D = tipo_livro, E = preço, F = paginas, G= editor, H = endereço editor, I = ano publicaçao
It is possible to <u>underline</u> -> {A, B,.. }
R1 = (_A_, _B_, D, E, F, G, H, I)
```

### *b)* 

```
2FN:
    R1 = (_A_, _B_, D, E, F, G, H, I)
    R2 = (_B_, C)
    R3 = (_D_, _F_, E)
    R4 = (_G_, H)


```




## ​7.3
 
### *a)*

```
Chaves: {A,B}

```


### *b)* 

```
    R1: {A,B,C}
	R2: {A,D,E,I,J}
	R3: {B,F,G,H}
```


### *c)* 

```
3FN:
    R1 = (_A_, _B_, C)
    R2 = (_A_, D, E)
    R3 = (_B_, F)
    R4 = (_D_, I, J)
    R5 = (_F_, G, H)
```


## ​7.4
 
### *a)*

```
    Chaves: {A,B}
```


### *b)* 

```
    R1: {A,B,C,D}
	R2: {D,E}
```


### *c)* 

```
    R1: {B,C,D}
	R2: {D,E}
	R3: {C,A}
```



## ​7.5
 
### *a)*

```
    Chaves: {A,B}
```

### *b)* 

```
    R1: {_A_, _B_, C, D, E}
    R2: {_A_, C, D}
```


### *c)* 

```
    R1: {_A_, _B_, C, D, E}
    R2: {_A_, C}
    R3: {C, D}
```

### *d)* 

```
    R1: {_A_, _B_, C, D, E}
    R2: {_A_, C}
    R3: {C, D}
```
