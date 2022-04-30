var WebSocketServer = require('ws').Server,
wss = new WebSocketServer({ port: 9000 });//服务端口8181

let cam=null;
let unity=null;

wss.on('connection', function (ws) {
    console.log('服务端：客户端已连接');
   

    ws.on('message', function (message) {
        //打印客户端监听的消息
        msg=message.toString();
        console.log(msg);
        
        if (msg=== "cam_connect"){
            cam=ws;
            console.log('检测到：图像识别程序');
        }
        else
        if (msg=== "unity_connect"){
            unity=ws;
            console.log('检测到：Unity');
        }
        
        if(ws===cam&&unity!=null)
            unity.send(msg);
    
    
    
        
        
       
    });
});