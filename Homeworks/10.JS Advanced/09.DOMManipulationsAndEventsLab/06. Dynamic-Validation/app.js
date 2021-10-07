function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange(ev) {
        const email = ev.target.value;
        if (/^[a-z]+@[a-z]+\.[a-z]+$/.test(email)) {
            ev.target.className = '';
        } else {
            ev.target.className = 'error';
        }
    }
}