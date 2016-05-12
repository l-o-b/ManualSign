document.getElementById('btn').onclick = function () {

    var newBtn = document.createElement('input');
    //newBtn.innerText = 'wewqer';
    newBtn.id='vod+';
    newBtn.type="checkbox";
    document.body.appendChild(newBtn);
}