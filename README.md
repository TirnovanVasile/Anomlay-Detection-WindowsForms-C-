# Detecția anomaliilor în procese industriale
### Aplicație C# / Windows Forms - Tennessee Eastman Process

---

## Descriere generală

Aplicația are ca scop detectarea automată a defecțiunilor în datele provenite de la senzori industriali, folosind setul de date Tennessee Eastman Process (TEP) - un standard în domeniul detecției anomaliilor în procese industriale.

Interfața grafică permite parcurgerea întregului flux de lucru, de la preprocesarea datelor brute până la antrenarea și evaluarea modelelor de învățare automată.

Sunt implementate patru metode de detecție:
- Rețea neuronală MLP cu backpropagation, implementată de la zero
- Autoencoder, pentru detecție nesupervizată bazată pe eroarea de reconstrucție
- Regresie Logistică prin biblioteca ML.NET
- Clustering K-Means prin biblioteca ML.NET

---

## Fluxul aplicației

### 1. Preprocesarea datelor

Datele brute din TEP sunt distribuite în patru fișiere CSV (antrenare normală, antrenare defectuoasă, testare normală, testare defectuoasă). Modulul de preprocesare extrage cele 52 de coloane relevante, elimină primele 100 de mostre din fiecare rulare de simulare (perioadă de stabilizare) și reduce eșantioanele cu 5% pe clasa defectuoasă pentru a reduce dezechilibrul dintre clase.

<img width="1156" height="699" alt="image" src="https://github.com/user-attachments/assets/49290ada-2ddb-41e1-b8c1-c438c79905b6" />


### 2. Încărcarea și pregătirea datelor

Fișierele procesate sunt încărcate în aplicație, iar valorile sunt normalizate în intervalul [0, 1] folosind normalizare min-max per coloană. Datele de antrenare sunt împărțite automat în set de antrenare și set de validare (implicit 90% / 10%), cu amestecare aleatorie înainte de împărțire.

<img width="1156" height="696" alt="Screenshot 2026-04-26 161444" src="https://github.com/user-attachments/assets/45ae96c4-7bdd-41de-a9fd-f485529bf15b" />
<img width="1154" height="690" alt="Screenshot 2026-04-26 161502" src="https://github.com/user-attachments/assets/e2df921b-2ebe-40a5-8a24-59ef6cf66e1d" />


### 3. Configurarea arhitecturii rețelei

Înainte de antrenare, utilizatorul definește structura rețelei neuronale: numărul de straturi ascunse, dimensiunea fiecărui strat și funcția de activare folosită (Sigmoid, Tanh, ReLU). De asemenea, se poate configura și inițializarea ponderilor sinaptice.

<img width="1156" height="694" alt="Screenshot 2026-04-26 161548" src="https://github.com/user-attachments/assets/5fe6b7af-910e-4bb3-93b1-61c91df3f976" />


### 4. Antrenarea rețelei MLP

Antrenarea rulează asincron, astfel încât interfața rămâne responsivă pe durata procesului. La fiecare epocă se efectuează propagarea înainte, calculul erorii și actualizarea ponderilor prin backpropagation. Graficul erorilor de antrenare și validare se actualizează în timp real, iar procesul se oprește fie la atingerea numărului maxim de epoci, fie când eroarea coboară sub pragul țintă.

<img width="1149" height="688" alt="Screenshot 2026-04-26 161734" src="https://github.com/user-attachments/assets/c87f1e74-0f35-40c9-9859-cabe8e57575e" />


### 5. Evaluarea rețelei MLP

Modelul antrenat este evaluat pe setul de test, iar rezultatele sunt prezentate prin mai multe metrici: acuratețe, eroare pătratică medie (MSE), rădăcina erorii pătratice medii (RMSE) și eroarea absolută medie (MAE). O mostră este clasificată ca defectuoasă dacă ieșirea rețelei depășește pragul de 0.5.

<img width="1152" height="688" alt="Screenshot 2026-04-26 161759" src="https://github.com/user-attachments/assets/53da2c3b-e139-46ba-b4d0-e988bfc8c5b0" />


### 6. Antrenarea și evaluarea Autoencoder-ului

Autoencoder-ul este antrenat exclusiv pe mostre normale, învățând să reconstruiască tiparele specifice funcționării corecte a procesului. La evaluare, eroarea de reconstrucție este calculată pentru fiecare mostră din setul de test - o eroare ridicată indică faptul că mostra se abate de la comportamentul normal și este clasificată ca anomalie. Pragul de decizie poate fi ajustat de utilizator. Sunt raportate acuratețea, precizia, recall-ul și scorul F1.

<img width="1153" height="684" alt="Screenshot 2026-04-26 161905" src="https://github.com/user-attachments/assets/da3c9ff8-9dc4-44cb-b753-97d9504b3810" />
<img width="1151" height="689" alt="Screenshot 2026-04-26 161932" src="https://github.com/user-attachments/assets/eac686c0-9232-4bdb-8a6e-4cc0e9e78617" />


### 7. Modele ML.NET

Ca alternativă la rețeaua neurală implementată manual, aplicația integrează două modele din biblioteca ML.NET: regresia logistică (SDCA) pentru clasificare supervizată și K-Means pentru clustering nesupervizat. Ambele modele sunt antrenate și evaluate pe aceleași date, permițând o comparație directă a rezultatelor.

<img width="392" height="247" alt="image" src="https://github.com/user-attachments/assets/b74e311f-9cec-4f7a-97a2-5f36617e748f" />


### 8. Salvarea și încărcarea modelului

Modelele antrenate (MLP și Autoencoder) pot fi exportate în format JSON și reîncărcate ulterior, fără a fi necesară reantrenarea. Fișierul salvat conține întreaga configurație a rețelei: ponderi, praguri și parametrii fiecărui strat.

<img width="792" height="577" alt="Screenshot 2026-04-26 162242" src="https://github.com/user-attachments/assets/f3e9ef8c-88fc-4bc6-99e8-4846a8314b83" />
<img width="703" height="552" alt="Screenshot 2026-04-26 162335" src="https://github.com/user-attachments/assets/804e0e29-c32e-4426-a320-73b965bcd9ed" />


---

## Setul de date

Tennessee Eastman Process este un proces chimic simulat, utilizat frecvent în literatura de specialitate pentru detecția defecțiunilor industriale. Setul de date conține 52 de variabile - 41 de măsurători de proces și 11 variabile manipulate - și acoperă atât scenarii de funcționare normală, cât și 21 de tipuri de defecte.

În cadrul acestui proiect, rulările 1–30 sunt folosite pentru antrenare, iar rulările 31–50 pentru testare. Primele 100 de mostre din fiecare rulare sunt excluse, deoarece corespund perioadei de inițializare a procesului.
