function notify(message) {
  
  let notification = document.getElementById('notification');
  notification.style.display = 'block';
  notification.textContent = message;

  notification.addEventListener('click', (ev) => {
    notification.style.display = 'none';
  })
}