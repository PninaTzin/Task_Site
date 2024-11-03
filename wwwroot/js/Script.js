// document.addEventListener('DOMContentLoaded', () => {
//     const loginDiv = document.getElementById('login');
//     const todoDiv = document.getElementById('todo');
//     const taskList = document.getElementById('taskList');
//     const taskDescription = document.getElementById('taskDescription');

//     const token = localStorage.getItem('token');

//     if (token) {
//         showTodoList();
//         loadTasks();
//     } else {
//         showLogin();
//     }

//     document.getElementById('loginButton').onclick = async () => {
//         const username = document.getElementById('username').value;
//         const password = document.getElementById('password').value;

//         const response = await fetch('http://localhost:5050/api/login', {
//             method: 'POST',
//             headers: {
//                 'Content-Type': 'application/json'
//             },
//             body: JSON.stringify({ UserName: username, Password: password }) // שים לב לשמות השדות
//         });

//         if (response.ok) {
//             const data = await response.json();
//             localStorage.setItem('token', data.token);
//             showTodoList();
//             loadTasks();
//         } else {
//             alert('שגיאת כניסה, נסה שוב.');
//         }
//     };

//     document.getElementById('addTaskButton').onclick = async () => {
//         const description = taskDescription.value;
//         const response = await fetch('http://localhost:5050/api/tasks', {
//             method: 'POST',
//             headers: {
//                 'Authorization': `Bearer ${token}`,
//                 'Content-Type': 'application/json'
//             },
//             body: JSON.stringify({ Description: description })
//         });

//         if (response.ok) {
//             loadTasks();
//             taskDescription.value = '';
//         }
//     };

//     async function loadTasks() {
//         const response = await fetch('http://localhost:5050/api/tasks/all', {
//             headers: {
//                 'Authorization': `Bearer ${token}`
//             }
//         });

//         const tasks = await response.json();
//         taskList.innerHTML = '';
//         tasks.forEach(task => {
//             const li = document.createElement('li');
//             li.textContent = task.description;
//             taskList.appendChild(li);
//         });
//     }

//     function showLogin() {
//         loginDiv.classList.remove('hidden');
//         todoDiv.classList.add('hidden');
//     }

//     function showTodoList() {
//         loginDiv.classList.add('hidden');
//         todoDiv.classList.remove('hidden');
//     }

//     document.getElementById('logoutButton').onclick = () => {
//         localStorage.removeItem('token');
//         showLogin();
//     };
// });



// script.js
document.addEventListener('DOMContentLoaded', () => {
    const loginDiv = document.getElementById('login');
    const todoDiv = document.getElementById('todo');
    const taskList = document.getElementById('taskList');
    const taskDescription = document.getElementById('taskDescription');

    const token = localStorage.getItem('token');

    if (token) {
        showTodoList();
        loadTasks();
        // } else {
        //     showLogin();
    }

    document.getElementById('loginButton').onclick = async () => {
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;

        const response = await fetch('http://localhost:5050/api/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ UserName: username, Password: password })
        });

        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('token', data.token);
            showTodoList();
            loadTasks();
        } else {
            alert('שגיאת כניסה, נסה שוב.');
        }
    };

    function openPostman() {
        const postmanURL = `https://app.getpostman.com/run-collection?request=POST&url=${encodeURIComponent(window.location.origin + '/api/login')}`;
        window.open(postmanURL, '_blank'); // פותח כרטיסייה חדשה עם הקישור ל-Postman
    }

    document.getElementById('addTaskButton').onclick = async () => {
        const description = taskDescription.value;
        const response = await fetch('http://localhost:5050/api/tasks', {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({Description: description })
        });

        if (response.ok) {
            loadTasks();
            taskDescription.value = '';
        }
    };

    async function loadTasks() {
        const response = await fetch('http://localhost:5050/api/tasks/all', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (response.ok) {
        const tasks = await response.json();
        taskList.innerHTML = '';
        tasks.forEach(task => {
            const li = document.createElement('li');
            li.textContent = task.description;
            taskList.appendChild(li);
        });
    } else {
        alert('שגיאה בטעינת המשימות'); // הוספת שגיאה אם טעינת המשימות נכשלה
    }

    }

    // function showLogin() {
    //     loginDiv.classList.remove('hidden');
    //     todoDiv.classList.add('hidden');
    // }

    function showTodoList() {
        loginDiv.classList.add('hidden');
        todoDiv.classList.remove('hidden');
    }

    document.getElementById('logoutButton').onclick = () => {
        localStorage.removeItem('token');
        showLogin();
    };

    // document.getElementById('viewUsersButton').onclick = () => {
    //     window.location.href = 'http://localhost:5050/api/users'; // קישור לרשימת המשתמשים
    // };
});

// document.addEventListener('DOMContentLoaded', function () {
//     displayTasks(); // עכשיו הקוד יופעל רק לאחר שהדף נטען
// });







// // פונקציה לפתיחת Postman עם קריאה לכניסה
// function openPostman() {
//     const postmanURL = `https://app.getpostman.com/run-collection?request=POST&url=${encodeURIComponent(window.location.origin + '/api/login')}`;
//     window.open(postmanURL, '_blank'); // פותח כרטיסייה חדשה עם הקישור ל-Postman
// }

// // פונקציה לביצוע כניסה
// async function login() {
//     const username = document.getElementById("username").value;
//     const password = document.getElementById("password").value;
//     // const response = await fetch('http://localhost:5050/api/tasks', {
//     try {
//         const response = await fetch('http://localhost:5050/api/login', {
//             method: "POST",
//             headers: { "Content-Type": "application/json" },
//             body: JSON.stringify({ username, password })

//         });
//         if (!response.ok) {
//             throw new Error(`HTTP error! status: ${response.status}`);
//         }

//         const data = await response.json();
//         if (data.success) {
//             localStorage.setItem('token', data.token); // שמירת הטוקן ב-local storage
//             document.getElementById('result').innerHTML = data.message;
//             // window.location.href = 'index.html'; // הפניה לדף המשימות
//             //     } else {
//             //         alert("Login failed: " + result.message);
//             //     }
//             // }
//         } else {
//             throw new Error('Unexpected response format');
//         }

//     } catch (error) {
//         console.error('Login failed:', error);
//         document.getElementById('result').innerHTML = 'Login failed: ' + error.message;
//     }
// }


// // פונקציה שמוודאת אם למשתמש יש הרשאות מנהל ומציגה קישורים מתאימים
// function checkAdminPrivileges() {
//     const token = localStorage.getItem('token');
//     if (token) {
//         const user = JSON.parse(atob(token.split('.')[1])); // ניתוח הטוקן כדי לשלוף מידע על המשתמש
//         if (user.role === 'admin') { // בדיקה אם למשתמש יש הרשאות מנהל
//             const adminLinksDiv = document.getElementById("adminLinks");
//             const currentPage = document.title;
//             if (currentPage === "Task Manager") {
//                 adminLinksDiv.innerHTML = '<a href="users.html">Go to Users List</a>';
//             } else if (currentPage === "Users List") {
//                 adminLinksDiv.innerHTML = '<a href="index.html">Go to Task Manager</a>';
//             }
//         }
//     }
// }

// // פונקציה שמוודאת אם יש טוקן ב-local storage
// function checkAuthentication() {
//     const token = localStorage.getItem('token'); // קח את הטוקן מה-local storage
//     if (!token) { // אם הטוקן לא קיים
//         window.location.href = 'login.html'; // הפנה לדף הכניסה
//     } else {
//         fetchTasks(); // אם הטוקן קיים, טען את המשימות
//     }
// }

// // הבאת כל המשימות
// async function fetchTasks() {
//     const userId = 2; // השתמש ב-ID של המשתמש המחובר
//     const response = await fetch(`http://localhost:5050/api/tasks/all/${userId}`);
//     const tasks = await response.json();
//     console.log(tasks); // מדפיס את התוצאות לקונסול
//     displayTasks(tasks);
// }
// // function displayTasks(tasks) {
// //     const tasksDiv = document.getElementById("tasks");
// //     tasksDiv.innerHTML = '';
// //     tasks.forEach(task => {
// //         const taskElement = document.createElement("div");
// //         taskElement.className = "task";
// //         taskElement.innerHTML = `
// //             <span>${task.description}</span>
// //             <button onclick="deleteTask(${task.taskId})">Delete</button>
// //         `;
// //         tasksDiv.appendChild(taskElement);
// //     });
// // }

// // function displayTasks(tasks) {
// //     const tasksDiv = document.getElementById("tasks");
// //     tasksDiv.innerHTML = '';
// //     tasks.forEach(task => {
// //         const taskElement = document.createElement("div");
// //         taskElement.className = "task";
// //         taskElement.innerHTML = `
// //             <span>${task.description}</span>
// //             <button onclick="deleteTask(${task.taskId})">Delete</button>
// //         `;
// //         tasksDiv.appendChild(taskElement);
// //     });
// // }


// // פונקציה להציג את המשימות
// function displayTasks(tasks) {
//     const tasksDiv = document.getElementById("tasks");
//     if (!tasksDiv) {
//         console.error("Element with ID 'tasks' not found");
//         return; // יוצאים אם האלמנט לא קיים
//     }
//     tasksDiv.innerHTML = ""; // מאפסים את התוכן הקודם
//     tasks.forEach(task => {
//         const taskDiv = document.createElement("div");
//         taskDiv.className = "task";
//         taskDiv.innerHTML = `
//             <span>${task.description}</span>
//             <button onclick="updateTask(${task.taskId})">Update</button>
//             <button onclick="deleteTask(${task.taskId})">Delete</button>
//         `;
//         tasksDiv.appendChild(taskDiv);
//     });
// }

// // // הצגת משימות
// // function displayTasks(tasks) {
// //     const tasksDiv = document.getElementById("tasks");
// //     tasksDiv.innerHTML = "";
// //     tasks.forEach(task => {
// //         const taskDiv = document.createElement("div");
// //         taskDiv.className = "task";
// //         taskDiv.innerHTML = `
// //             <span>${task.description}</span>
// //             <button onclick="updateTask(${task.taskId})">Update</button>
// //             <button onclick="deleteTask(${task.taskId})">Delete</button>
// //         `;
// //         tasksDiv.appendChild(taskDiv);
// //     });
// // }

// // // הוספת משימה חדשה
// // async function addTask() {
// //     const description = document.getElementById("taskDescription").value;
// //     const response = await fetch(`http://localhost:5050/api/tasks${userId}`, {
// //         method: "POST",
// //         headers: { "Content-Type": "application/json" },
// //         body: JSON.stringify({ description, status: false })
// //     });
// //     const result = await response.json();
// //     if (result.success) {
// //         fetchTasks();
// //     } else {
// //         alert("Failed to add task: " + result.message);
// //     }
// // }


// async function addTask() {
//     const description = document.getElementById("taskDescription").value;
//     const userId = 1; // הכנס את המשתמש הנוכחי כאן

//     // ודא שהתיאור אינו ריק
//     if (!description) {
//         alert("Please enter a task description.");
//         return;
//     }

//     const response = await fetch(`http://localhost:5050/api/tasks/${userId}`, {
//         method: "POST",
//         headers: { "Content-Type": "application/json" },
//         body: JSON.stringify({ description, status: false })
//     });

//     // טיפול בשגיאות בבקשה
//     if (!response.ok) {
//         const error = await response.json();
//         alert("Failed to add task: " + error.message);
//         return;
//     }

//     const result = await response.json();
//     if (result.success) {
//         fetchTasks(); // קריאה לעדכון המשימות
//     } else {
//         alert("Failed to add task: " + result.message);
//     }
// }

// // עדכון משימה
// async function updateTask(taskId) {
//     const newDescription = prompt("Enter new description:");
//     const response = await fetch(`http://localhost:5050/api/tasks${userId}/update/${taskId}`, {
//         method: "PUT",
//         headers: { "Content-Type": "application/json" },
//         body: JSON.stringify({ description: newDescription, status: false })
//     });
//     const result = await response.json();
//     if (result.success) {
//         fetchTasks();
//     } else {
//         alert("Failed to update task: " + result.message);
//     }
// }

// // מחיקת משימה
// async function deleteTask(taskId) {
//     const response = await fetch(`/http://localhost:5050/api/tasks${userId}/delete/${taskId}`, { method: "DELETE" });
//     const result = await response.json();
//     if (result.success) {
//         fetchTasks();
//     } else {
//         alert("Failed to delete task: " + result.message);
//     }
// }

// // פונקציית הכניסה
// // async function login() {
// //     const username = document.getElementById("username").value;
// //     const password = document.getElementById("password").value;

// //     // כאן תבצע את בקשת הכניסה לשרת
// //     const response = await fetch('http://localhost:5050/api/login', {
// //         method: "POST",
// //         headers: { "Content-Type": "application/json" },
// //         body: JSON.stringify({ username, password })
// //     });

// //     const result = await response.json();
// //     if (result.success) {
// //         localStorage.setItem('token', result.token); // שמור את הטוקן ב-local storage
// //         window.location.href = 'index.html'; // הפנה לדף המשימות
// //     } else {
// //         alert("Login failed: " + result.message);
// //     }
// // }


// // פונקציה להתחברות
// async function login() {
//     const username = document.getElementById("username").value;
//     const password = document.getElementById("password").value;

//     const response = await fetch('http://localhost:5050/api/login', {
//         method: 'POST',
//         headers: {
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify({ username, password })
//     });

//     if (!response.ok) {
//         const error = await response.json();
//         alert("Login failed: " + error.message);
//         return;
//     }

//     const result = await response.json();
//     if (result.success) {
//         // הכנס כאן קוד להמשך אחרי התחברות מוצלחת
//         console.log("Login successful");
//         fetchTasks(); // קריאה להציג את המשימות
//     } else {
//         alert("Login failed: " + result.message);
//     }
// }

// // בדוק את האימות כשנכנסים לדף המשימות
// if (document.title === "Task Manager") {
//     checkAuthentication();
// }

// // async function login() {
// //     const username = document.getElementById("username").value;
// //     const password = document.getElementById("password").value;

// //     const response = await fetch('http://localhost:5050/api/login', {
// //         method: "POST",
// //         headers: { "Content-Type": "application/json" },
// //         body: JSON.stringify({ username, password })
// //     });

// //     const result = await response.json();
// //     if (result.success) {
// //         localStorage.setItem('token', result.token); // שמירת הטוקן ב-local storage
// //         window.location.href = 'index.html'; // הפניה לדף המשימות
// //     } else {
// //         alert("Login failed: " + result.message);
// // }
// // }

// // בדוק את ההרשאות כאשר הדף נטען
// checkAdminPrivileges();
// // fetchTasks();
