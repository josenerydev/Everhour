ansible-vault encrypt secrets.yml
ansible-vault encrypt hosts.ini

ansible-playbook main.yml --ask-vault-pass
ansible-playbook ping.yml --ask-vault-pass
ansible-playbook restart-machines.yml --ask-vault-pass
