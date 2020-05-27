<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[ProductProduct]].
 *
 * @see ProductProduct
 */
class ProductProductQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return ProductProduct[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return ProductProduct|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
