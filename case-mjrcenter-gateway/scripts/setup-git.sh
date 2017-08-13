sudo mkdir /usr/local/bin/mjrcenter-gateway
sudo chmod 777 /usr/local/bin/mjrcenter-gateway
cd /usr/local/bin/mjrcenter-gateway
git init
git remote add origin https://github.com/Euricom/case-mjrcenter-gateway.git
git pull origin master
git branch -u origin/master master
