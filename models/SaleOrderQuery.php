<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[SaleOrder]].
 *
 * @see SaleOrder
 */
class SaleOrderQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return SaleOrder[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return SaleOrder|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
