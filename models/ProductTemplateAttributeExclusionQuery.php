<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[ProductTemplateAttributeExclusion]].
 *
 * @see ProductTemplateAttributeExclusion
 */
class ProductTemplateAttributeExclusionQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return ProductTemplateAttributeExclusion[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return ProductTemplateAttributeExclusion|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
