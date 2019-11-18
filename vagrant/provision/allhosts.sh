# Add hostname
cat > hosts << EOF
127.0.0.1	localhost

# The following lines are desirable for IPv6 capable hosts
::1     localhost ip6-localhost ip6-loopback
ff02::1 ip6-allnodes
ff02::2 ip6-allrouters

192.168.16.70 mongo-config-1
192.168.16.71 mongo-config-2
192.168.16.69 mongo-query-router
192.168.16.72 mongo-shard-1
192.168.16.73 mongo-shard-2
192.168.16.74 mongo-shard-
EOF
sudo mv -v hosts /etc/hosts

# Copy APT sources list
sudo cp /vagrant/sources/sources.list /etc/apt/
sudo cp /vagrant/sources/mongodb-org-4.2.list /etc/apt/sources.list.d/

# Add MongoDB repo key
sudo apt-get install gnupg
wget -qO - https://www.mongodb.org/static/pgp/server-4.2.asc | sudo apt-key add -

# Update Repository
sudo apt-get update
# sudo apt-get upgrade -y

# Install MongoDB
sudo apt-get install -y mongodb-org

# Enable and Start MongoDB
sudo systemctl enable mongod
sudo service start mongod

mkdir -pv /opt/mongo
cp -v /vagrant/mongo-keyfile /opt/mongo/