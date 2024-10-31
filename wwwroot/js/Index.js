// const userId = 1;

// async function fetchTasks() {
//     const response = await fetch(`/api/tasks/all/${userId}`);
//     const tasks = await response.json();
//     displayTasks(tasks);
// }

// function displayTasks(tasks) {
//     const tasksDiv = document.getElementById("tasks");
//     tasksDiv.innerHTML = "";
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

// async function addTask() {
//     const description = document.getElementById("taskDescription").value;
//     const response = await fetch(`/api/tasks/${userId}`, {
//         method: "POST",
//         headers: { "Content-Type": "application/json" },
//         body: JSON.stringify({ description, status: false })
//     });
//     const result = await response.json();
//     if (result.success) {
//         fetchTasks();
//     } else {
//         alert("Failed to add task: " + result.message);
//     }
// }

// // עדכון משימה
// async function updateTask(taskId) {
//     const newDescription = prompt("Enter new description:");
//     const response = await fetch(`/api/tasks/${userId}/update/${taskId}`, {
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
//     const response = await fetch(`/api/tasks/${userId}/delete/${taskId}`, { method: "DELETE" });
//     const result = await response.json();
//     if (result.success) {
//         fetchTasks();
//     } else {
//         alert("Failed to delete task: " + result.message);
//     }
// }

// // טעינה ראשונית
// fetchTasks();