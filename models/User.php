<?php

namespace app\models;
use yii\db\ActiveRecord;
use yii\web\IdentityInterface;

class User extends ActiveRecord   implements \yii\web\IdentityInterface  {

    public $id;
    public $username;
    public $password;
    public $authKey;
    public $accessToken;
    public $login;
    
    /*private static $users = [
        '100' => [
            'id' => '100',
            'username' => 'EnriqueM',
            'authKey' => 'test100key',
            'accessToken' => '100-token',
        ],
        '101' => [
            'id' => '101',
            'username' => 'Enrique2',
            'password' => '123456',
            'authKey' => 'test101key',
            'accessToken' => '101-token',
        ],
    ];*/

    public static function tableName(){
      
        return 'res_users';
    }

    /**
     * {@inheritdoc}
     */
    public static function findIdentity($id)
    {
        //return isset(self::$users[$id]) ? new static(self::$users[$id]) : null;
        return static::findOne($id);
    }

    /**
     * {@inheritdoc}
     */
    public static function findIdentityByAccessToken($token, $type = null)
    {
        
        /*foreach (self::$users as $user) {
            if ($user['accessToken'] === $token) {
                return new static($user);
            }
        }
        return null;
        */
        return static::findOne(['access_token' => $token]);

    }

    /**
     * Finds user by username
     *
     * @param string $username
     * @return static|null
     */
    /*public static function findByUsername($username)
    {
        foreach (self::$users as $user) {
            if (strcasecmp($user['username'], $username) === 0) {
                return new static($user);
            }
        }

        return null;
    }*/
    public static function findByUsername($login)
    {
       
        return self::findOne(['login'=>$login]);
      
    }


    /**
     * {@inheritdoc}
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * {@inheritdoc}
     */
    public function getAuthKey()
    {
        return $this->authKey;
    }

    /**
     * {@inheritdoc}
     */
    public function validateAuthKey($authKey)
    {
        return $this->authKey === $authKey;
    }

   
    public function validatePassword($password)
    {
        return $this->password === $password;
    }

    public function  inicioSes(){
        
    }



}
