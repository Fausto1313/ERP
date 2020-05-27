<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[ResCompany]].
 *
 * @see ResCompany
 */
class ResCompanyQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return ResCompany[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return ResCompany|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
