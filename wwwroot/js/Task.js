// הבאת כל המשימות
async function fetchTasks() {
    const userId = 1; // השתמש ב-ID של המשתמש המחובר
    const response = await fetch(`http://localhost:5000/index.html/api/tasks/all/${userId}`);
    const tasks = await response.json();
    console.log(tasks); // מדפיס את התוצאות לקונסול
    displayTasks(tasks);
}
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
    const response = await fetch(`http://localhost:5000/index.html/api/tasks${userId}`, {
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
    const response = await fetch(`http://localhost:5000/index.html/api/tasks${userId}/update/${taskId}`, {
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
    const response = await fetch(`http://localhost:5000/index.html/api/tasks${userId}/delete/${taskId}`, { method: "DELETE" });
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
    const response = await fetch('http://localhost:5000/index.html/api/login', {
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

checkAdminPrivileges();
fetchTasks();