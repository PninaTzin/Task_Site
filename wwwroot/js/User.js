function checkAuthentication() {
    const token = localStorage.getItem('token'); // קח את הטוקן מה-local storage
    if (!token) { // אם הטוקן לא קיים
        window.location.href = 'login.html'; // הפנה לדף הכניסה
    } else {
        fetchTasks(); // אם הטוקן קיים, טען את המשימות
    }
}
