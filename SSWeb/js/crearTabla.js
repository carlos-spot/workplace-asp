function mostrarTabla(psrc) {
    mywindow = window.open("", "mywindow", "location=0,status=0,scrollbars=1,width=700,height=600");
    var x = (screen.width /2)/2;
    var y = (screen.height / 2) / 2;
    y = y - 100;
    mywindow.moveTo(x, y);
    mywindow.document.write(psrc);
    mywindow.title = "Survey System";
    
}