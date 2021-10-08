function attachEventsListeners() {
    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondesInput = document.getElementById('seconds');

    document.querySelector('main').addEventListener('click', (ev) => {

        if (ev.target.type == 'button' && ev.target.id == 'daysBtn') {
            const inputValue = ev.target.parentElement.children[1].value;

            hoursInput.value = Number(inputValue) * 24;
            minutesInput.value = Number(inputValue) * 24 * 60;
            secondesInput.value = Number(inputValue) * 24 * 60 * 60;
        } else if (ev.target.type == 'button' && ev.target.id == 'hoursBtn') {
            const inputValue = ev.target.parentElement.children[1].value;

            daysInput.value = Number(inputValue) / 24;
            minutesInput.value = Number(inputValue) * 60;
            secondesInput.value = Number(inputValue) * 60 * 60;
        } else if (ev.target.type == 'button' && ev.target.id == 'minutesBtn') {
            const inputValue = ev.target.parentElement.children[1].value;

            daysInput.value = Number(inputValue) / 24 / 60;
            hoursInput.value = Number(inputValue) / 60;
            secondesInput.value = Number(inputValue) * 60;
        } else if (ev.target.type == 'button' && ev.target.id == 'secondsBtn') {
            const inputValue = ev.target.parentElement.children[1].value;

            daysInput.value = Number(inputValue) / 24 / 60 / 60;
            hoursInput.value = Number(inputValue) / 60 / 60;
            minutesInput.value = Number(inputValue) / 60;
        }
    })
}