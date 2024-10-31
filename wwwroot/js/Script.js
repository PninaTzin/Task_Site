// פונקציה לפתיחת Postman עם קריאה לכניסה
// function openPostman() {
//     const postmanURL = `https://app.getpostman.com/run-collection?request=POST&url=${encodeURIComponent(window.location.origin + '/api/login')}`;
//     window.open(postmanURL, '_blank'); // פותח כרטיסייה חדשה עם הקישור ל-Postman
// }

// פונקציה לביצוע כניסה
async function login() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    const response = await fetch('http://localhost:5050/api/tasks', {
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


// פונקציה שמוודאת אם למשתמש יש הרשאות מנהל ומציגה קישורים מתאימים
function checkAdminPrivileges() {
    const token = localStorage.getItem('token');
    if (token) {
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
    }
}

// פונקציה שמוודאת אם יש טוקן ב-local storage
function checkAuthentication() {
    const token = localStorage.getItem('token'); // קח את הטוקן מה-local storage
    if (!token) { // אם הטוקן לא קיים
        window.location.href = 'login.html'; // הפנה לדף הכניסה
    } else {
        fetchTasks(); // אם הטוקן קיים, טען את המשימות
    }
}

// הבאת כל המשימות
async function fetchTasks() {
    const userId = 1; // השתמש ב-ID של המשתמש המחובר
    const response = await fetch(`http://localhost:5050/api/tasks/all/${userId}`);
    const tasks = await response.json();
    console.log(tasks); // מדפיס את התוצאות לקונסול
    displayTasks(tasks);
}
// function displayTasks(tasks) {
//     const tasksDiv = document.getElementById("tasks");
//     tasksDiv.innerHTML = '';
//     tasks.forEach(task => {
//         const taskElement = document.createElement("div");
//         taskElement.className = "task";
//         taskElement.innerHTML = `
//             <span>${task.description}</span>
//             <button onclick="deleteTask(${task.taskId})">Delete</button>
//         `;
//         tasksDiv.appendChild(taskElement);
//     });
// }

function displayTasks(tasks) {
    const tasksDiv = document.getElementById("tasks");
    tasksDiv.innerHTML = '';
    tasks.forEach(task => {
        const taskElement = document.createElement("div");
        taskElement.className = "task";
        taskElement.innerHTML = `
            <span>${task.description}</span>
            <button onclick="deleteTask(${task.taskId})">Delete</button>
        `;
        tasksDiv.appendChild(taskElement);
    });
}

// הצגת משימות
function displayTasks(tasks) {
    const tasksDiv = document.getElementById("tasks");
    tasksDiv.innerHTML = "";
    tasks.forEach(task => {
        const taskDiv = document.createElement("div");
        taskDiv.className = "task";
        taskDiv.innerHTML = `
            <span>${task.description}</span>
            <button onclick="updateTask(${task.taskId})">Update</button>
            <button onclick="deleteTask(${task.taskId})">Delete</button>
        `;
        tasksDiv.appendChild(taskDiv);
    });
}

// הוספת משימה חדשה
async function addTask() {
    const description = document.getElementById("taskDescription").value;
    const response = await fetch(`http://localhost:5050/api/tasks${userId}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ description, status: false })
    });
    const result = await response.json();
    if (result.success) {
        fetchTasks();
    } else {
        alert("Failed to add task: " + result.message);
    }
}

// עדכון משימה
async function updateTask(taskId) {
    const newDescription = prompt("Enter new description:");
    const response = await fetch(`http://localhost:5050/api/tasks${userId}/update/${taskId}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ description: newDescription, status: false })
    });
    const result = await response.json();
    if (result.success) {
        fetchTasks();
    } else {
        alert("Failed to update task: " + result.message);
    }
}

// מחיקת משימה
async function deleteTask(taskId) {
    const response = await fetch(`/http://localhost:5050/api/tasks${userId}/delete/${taskId}`, { method: "DELETE" });
    const result = await response.json();
    if (result.success) {
        fetchTasks();
    } else {
        alert("Failed to delete task: " + result.message);
    }
}

// פונקציית הכניסה
async function login() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    // כאן תבצע את בקשת הכניסה לשרת
    const response = await fetch('http://localhost:5050/api/login', {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password })
    });
    
    const result = await response.json();
    if (result.success) {
        localStorage.setItem('token', result.token); // שמור את הטוקן ב-local storage
        window.location.href = 'index.html'; // הפנה לדף המשימות
    } else {
        alert("Login failed: " + result.message);
    }
}

// בדוק את האימות כשנכנסים לדף המשימות
if (document.title === "Task Manager") {
    checkAuthentication();
}

async function login() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    const response = await fetch('http://localhost:5050/api/login', {
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

// בדוק את ההרשאות כאשר הדף נטען
checkAdminPrivileges();
fetchTasks();
