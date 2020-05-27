<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[ResUsers]].
 *
 * @see ResUsers
 */
class ResUsersQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return ResUsers[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return ResUsers|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
