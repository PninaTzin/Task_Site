async function login() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    const response = await fetch('http://localhost:5000/index.html/api/tasks', {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password })
    });
    
    const result = await response.json();
    if (result.success) {
        localStorage.setItem('token', result.token); // שמירת הטוקן ב-local storage
        window.location.href = 'index.html'; // הפניה לדף המשימות
    } else {
        alert("Login failed: " + result.message);
    }
}

function checkAdminPrivileges() {
    const token = localStorage.getItem('token');
    if (token) {
        try {
            const user = JSON.parse(atob(token.split('.')[1])); // ניתוח הטוקן כדי לשלוף מידע על המשתמש
            if (user.role === 'admin') { // בדיקה אם למשתמש יש הרשאות מנהל
                const adminLinksDiv = document.getElementById("adminLinks");
                const currentPage = document.title;
                if (currentPage === "Task Manager") {
                    adminLinksDiv.innerHTML = '<a href="users.html">Go to Users List</a>';
                } else if (currentPage === "Users List") {
                    adminLinksDiv.innerHTML = '<a href="index.html">Go to Task Manager</a>';
                }
            }
        } catch (error) {
            console.error("Failed to parse token:", error);
        }
    }
}
