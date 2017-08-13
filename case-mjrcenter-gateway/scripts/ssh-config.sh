## No passfrase!!
ssh-keygen -t rsa -b 2048 -f ~/.ssh/id_rsa
ssh-copy-id -i ~/.ssh/id_rsa.pub msdn@MyDockerVM
