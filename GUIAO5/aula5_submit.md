# BD: Guião 5


## ​Problema 5.1
 
### *a)*

```
Write here your answer e.g:
(π Pname, Pnumber (project) ⨝ Pno=Pnumber (works_on)) ⨝.... 
```


### *b)* 

```
π Fname, Lname, employee.Ssn (employee ⨝ employee.Super_ssn = supervisor.Ssn (ρ supervisor (π Ssn ( σ(Fname ='Carlos' and Lname='Gomes') (employee)))))
```


### *c)* 

```
γ Pname, Pnumber; sum(Hours)-> TotalHours (project ⨝ project.Pnumber = works_on.Pno works_on)
```


### *d)* 

```
π Fname, Minit, Lname, Pname, Dno, Hours (σ (Pname='Aveiro Digital' ∧ Dnum = 3 ∧ Hours > 20) ((project) ⨝ Pnumber = Pno (employee ⨝ Ssn = Essn works_on)))
```


### *e)* 

```
π Fname, Minit, Lname (σ Pno=null (employee⟕Ssn=Essn works_on))
```


### *f)* 

```
γ Dname;Average_Women_Salary←avg(employee.Salary) (department⨝ Dnumber=Dno σSex='F' (employee))
```


### *g)* 

```
σ nDependentes > 2 (γ Fname, Minit, Lname ; nDependentes←count(Essn) (employee ⨝ Ssn = Essn dependent))
```


### *h)* 

```
πFname,Lname (σMgr_ssn ≠ Essn (employee ⨝ Ssn = Mgr_ssn department ⟕ Mgr_ssn = Essn dependent))
```


### *i)* 

```
π Fname, Minit, Lname, Address ((employee⨝Ssn=Essn works_on⨝Pno=Pnumber (σ Plocation='Aveiro' project))⨝Dno=Dnumber  (σ Dlocation!='Aveiro' (department⟕dept_location)))
```


## ​Problema 5.2

### *a)*

```
πnome,nif,fax,endereco,condpag,tipo (σfornecedor=null (encomenda⟗fornecedor=nif (fornecedor)))
```

### *b)* 

```
π nome, codProd, avgUnidades (produto ⨝ codigo = item.codProd ( γ codProd; avgUnidades←avg(item.unidades) (item) ))
```


### *c)* 

```
γ;nprod_avg←avg(nprodutos) (γnumEnc;nprodutos←count(codProd) (item))
```


### *d)* 

```
πproduto.codigo,nif,fornecedor.nome,qtd_total ((γcodProd,fornecedor;qtd_total←sum(item.unidades) (item⨝numEnc = numero encomenda))⨝ fornecedor=nif fornecedor ⨝ codProd = codigo produto)

```


## ​Problema 5.3

### *a)*

```
π paciente.nome, paciente.numUtente (σ prescricao.numUtente = null ( (paciente) ⟕ paciente.numUtente = prescricao.numUtente (prescricao))
) 
```

### *b)* 

```
γ medico.especialidade; numPresc←count(numPresc) (medico ⨝ numSNS=numMedico prescricao)

```


### *c)* 

```
γfarmacia;PrescrPorFarm←count(farmacia) (prescricao ⨝ farmacia = nome farmacia)
```


### *d)* 

```
πnumRegFarm,nome,formula (σnumRegFarm= 906 ∧ numPresc = null (farmaco ⟕ (farmaco ⟕ nome = nomeFarmaco presc_farmaco)))
```

### *e)* 

```
γ farmacia.nome, numRegFarm; farmacosVendidos←count(prescricao.numPresc) (presc_farmaco ⨝ presc_farmaco.numPresc = prescricao.numPresc ((prescricao) ⨝ farmacia = nome (farmacia)))
```

### *f)* 

```
paciente ⨝ π numUtente σ numMedicos > 1 (γ numUtente; numMedicos←count(numMedico) (π numUtente, numMedico prescricao))

```
