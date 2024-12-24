ansible-vault encrypt secrets.yml
ansible-vault encrypt hosts.ini

ansible-playbook main.yml --ask-vault-pass
