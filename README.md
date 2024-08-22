# mediafon_tech_task
TODO: add instructions on running and deployment. Add git actions for build?...


PostgreSQL: v16.4




TODO: Remove these entries when repo is ready

* pg (todo: user for app?)
	* usr: postgres
	* psw: pg-admin-psw
	* prt: 5432
	
	
	
	
## task:

1) .Net core + Angular + PostgreSQL
2) Login forma, prie kurios prisijungiama su vartotojo vardu ir slaptažodžiu. (vartotojo duomenys saugomi DB)
3) Prisijungus, atidaroma paraiškų sąrašo forma. Sąrašo laukeliai (id, data, paraiškos tipas (prašymas/pasiūlymas/skundas), būsena (pateiktas/įvykdytas)
4) Formoje galimybė pildyti naują paraišką. Paspaudus mygtuką "Nauja paraiška" atidaromas Popup'as, paraiškos pildymui.
5) Pildymo laukai:
  a) Prašymo tipas
  b) Žinutes laukas
6) Pateikus paraišką, paraiška sąraše atvaizduojama su statusu "pateiktas"
7) App background'e sukasi hosted servisas, kuris po 1 min pažymi paraišką, kaip "įvykdytas".
8) Paraiškų sąraše, paraiškos statusas atsinaujina, neperkrovus formos.